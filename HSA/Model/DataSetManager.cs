using System;
using System.Data;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using HSA.Tree;

namespace HSA.Model
{
    public class DataSetManager
    {

        private CultureInfo culture;

        // ----------------------------------------------------------------------------------------------------

        // Information of the data filtered

        private DataView dataFiltered;

        public DataView DataFiltered 
        {
            get
            {
                return dataFiltered;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the data

        private DataTable data;

        public DataTable Data
        {
            get
            {
                return data;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the current page data

        DataTable currentPageData;

        public DataTable CurrentPageData
        {
            get
            {
                return currentPageData;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the decision tree

        DecisionTree decisionTree;

        public DecisionTree Decision_Tree
        {
            get
            {
                return decisionTree;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the data count

        private int dataCount;

        public int DataCount
        {
            get
            {
                return dataCount;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the current page

        private int currentPage;

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of max page

        private int maxPage;

        public int MaxPage
        {
            get
            {
                return maxPage;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the lower limit

        private int lowerLimit; 

        public int LowerLimit
        {
            get
            {
                return lowerLimit;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Information of the upper limit

        private int upperLimit; 

        public int UpperLimit
        {
            get
            {
                return upperLimit;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Constant information

        public const int DataCountPerPage = 250;

        // ----------------------------------------------------------------------------------------------------

        // Method data set manager

        public DataSetManager()
        {
            culture = new CultureInfo("us");
            data = new DataTable();
            currentPageData = new DataTable();
            data.Locale = culture;
            LoadData();
            currentPage = 1;
            dataFiltered = new DataView(data);
            UpdatePageLimits();
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method load data

        private void LoadData()
        {
            //Reads file content
            string path = Directory.GetCurrentDirectory().Replace("HSA\\bin\\", "data\\kc_house_data.csv");
            path = path.Replace("Debug", "");
            path = path.Replace("x64\\", "");
            path = path.Replace("x86\\", "");
            
            string[] rawData = File.ReadAllLines(path);

            //Adds columns, [0] is for data types
            List<string> columnsTypesBeforePriceRange = rawData[0].Split(',').ToList();
            List<string> columnsNamesBeforePriceRange = rawData[1].Split(',').ToList();

            columnsTypesBeforePriceRange.Add("String");
            columnsNamesBeforePriceRange.Add("price_range");

            string[] columnsTypes = columnsTypesBeforePriceRange.ToArray();
            string[] columnsNames = columnsNamesBeforePriceRange.ToArray();

            for (int i = 0; i < columnsNames.Length; i++)
            {
                data.Columns.Add(columnsNames[i], Type.GetType("System." + columnsTypes[i]));
                currentPageData.Columns.Add(columnsNames[i], Type.GetType("System." + columnsTypes[i]));
            }

            //Adds rows
            for (int i = 2; i < rawData.Length; i++)
            {
                string[] row = rawData[i].Split(',');

                DataRow newRow = data.NewRow();

                for (int j = 0; j < row.Length; j++)
                {
                    //For special format for some types

                    Type columnType = data.Columns[j].DataType;
                    String value = row[j].Replace("\"", "");

                    if (columnType.Equals(typeof(DateTime)))
                    {
                        //Format  yyyyMMddThhmmss

                        newRow[columnsNames[j]] = DateTime.ParseExact(value, "yyyyMMddThhmmss", culture);
                    }
                    else if (columnType.Equals(typeof(Boolean)))
                    {
                        if (value.Equals("1"))
                        {
                            newRow[columnsNames[j]] = true;
                        }
                        else
                        {
                            newRow[columnsNames[j]] = false;
                        }
                    }
                    else
                    {
                        newRow[columnsNames[j]] = value;
                    }
                }
                AddPriceRange(newRow);

                data.Rows.Add(newRow);
            }
            
        }

        // ----------------------------------------------------------------------------------------------------

        // Method add prices range

        private void AddPriceRange(DataRow newRow)
        {
            double price = (Double)newRow["price"];
            double difference = 100000;

            string range = "";

            for (int i = 0; i < 40; i++)
            {
                double bottomLimit = i * difference;
                double topLimit = (i+1) * difference;

                if (price >= bottomLimit && price < topLimit) 
                { 
                    range = "["+ bottomLimit +"-"+ topLimit+")";
                }
            }
            if (range.Equals(""))
            {
                range = "[4000000-7700000]";
            }

            newRow[(newRow.ItemArray.Length-1)] = range;
        }

        // ----------------------------------------------------------------------------------------------------

        // Method refresh data

        private void RefreshData()
        {
            UpdatePageLimits();

            DataRowCollection currentPageRows = currentPageData.Rows;

            currentPageRows.Clear();

            for (int i = lowerLimit; i < upperLimit; i++)
            {
                currentPageData.ImportRow(dataFiltered[i].Row);
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method next page

        public int NextPage()
        {
            if (currentPage < maxPage)
            {
                currentPage++;

                UpdatePageLimits();

                DataRowCollection currentPageRows = currentPageData.Rows;
                currentPageRows.Clear();

                for (int i = lowerLimit; i < upperLimit; i++)
                {
                    currentPageData.ImportRow(dataFiltered[i].Row);
                }

                return currentPage;
            }
            else
            {
                return - 1;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method previous page

        public int PreviousPage()
        {
            if (currentPage > 1)
            {
                currentPage--;

                UpdatePageLimits();

                DataRowCollection rows = data.Rows;

                DataRowCollection currentPageRows = currentPageData.Rows;

                currentPageRows.Clear();

                for (int i = lowerLimit; i < upperLimit; i++)
                {
                    currentPageData.ImportRow(dataFiltered[i].Row);
                }

                return currentPage;
            }
            else
            {
                return -1;
            }
        }

        // ----------------------------------------------------------------------------------------------------

        // Method update page limits

        private void UpdatePageLimits()
        {
            dataCount = dataFiltered.Count;
            maxPage = (int)Math.Ceiling((dataCount + (0.0d)) / DataCountPerPage);
            lowerLimit = currentPage * DataCountPerPage - DataCountPerPage;
            upperLimit = (currentPage >= maxPage ? dataCount : lowerLimit + DataCountPerPage);
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter string data

        public void FilterStringData(String columnName, String subString)//OK
        {
            dataFiltered.RowFilter = $"{columnName} LIKE \'%{subString}%'";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter integer data

        public void FilterIntegerData(String columnName, int from, int to)//OK
        {
            dataFiltered.RowFilter = $"{columnName} >= {from} AND {columnName} <= {to}";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter double data

        public void FilterDoubleData(String columnName, double from, double to)//OK
        {
            dataFiltered.RowFilter = $"{columnName} >= {from} AND {columnName}<= {to}";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter boolean data

        public void FilterBooleanData(String columnName, bool value)
        {
            dataFiltered.RowFilter = $"{columnName} = {value}";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method filter date data

        public void FilterDateData(String columnName, DateTime from, DateTime to)//NOT WORKING
        {
            dataFiltered.RowFilter = $"{columnName} >= #{from.ToString()}# AND {columnName} <= #{to.ToString()}#";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method sort data

        public void SortData(String columnName, bool ascendant)
        {
            if (ascendant)
            {
                dataFiltered.Sort = $"{columnName} ASC";
            }
            else
            {
                dataFiltered.Sort = $"{columnName} DESC";
            }

            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

        // Method clear sort filters

        public void ClearSortFiters()
        {
            dataFiltered.RowFilter = "";
            dataFiltered.Sort = "";
            currentPage = 1;
            RefreshData();
        }

        // ----------------------------------------------------------------------------------------------------

    }
}


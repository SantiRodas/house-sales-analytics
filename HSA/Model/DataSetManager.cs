using System;
using System.Data;
using System.IO;
using System.Globalization;

namespace HSA.Model
{
    public class DataSetManager
    {
        private DataView dataFiltered;

        private DataTable data;

        public DataView DataFiltered 
        {
            get
            {
                return dataFiltered;
            }
        }

        public DataTable Data
        {
            get
            {
                return data;
            }
        }

        DataTable currentPageData;

        public DataTable CurrentPageData
        {
            get
            {
                return currentPageData;
            }
        }

        private int dataCount;
        public int DataCount
        {
            get
            {
                return dataCount;
            }
        }

        private int currentPage;

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
        }

        private int maxPage;

        public int MaxPage
        {
            get
            {
                return maxPage;
            }
        }

        private int lowerLimit; //From

        public int LowerLimit
        {
            get
            {
                return lowerLimit;
            }
        }

        private int upperLimit; //The next to the last one
        public int UpperLimit
        {
            get
            {
                return upperLimit;
            }
        }

        public const int DataCountPerPage = 250;

        public DataSetManager()
        {
            data = new DataTable();
            currentPageData = new DataTable();
            LoadData();
            currentPage = 1;
            dataFiltered = new DataView(data);
            UpdatePageLimits();
            RefreshData();                     
        }

        private void LoadData()
        {
            //Reads file content
            string path = Directory.GetCurrentDirectory().Replace("HSA\\bin\\Debug", "data\\kc_house_data.csv");

            string[] rawData = File.ReadAllLines(path);

            //Adds columns, [0] is for data types
            string[] columnsTypes = rawData[0].Split(',');
            string[] columnsNames = rawData[1].Split(',');

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
                        newRow[columnsNames[j]] = DateTime.ParseExact(value, "yyyyMMddThhmmss", CultureInfo.CurrentCulture);

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
                data.Rows.Add(newRow);
            }
        }

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

        public int NextPage()
        {
            if (currentPage < maxPage)
            {
                currentPage++;

                UpdatePageLimits();
                DataRowCollection rows = data.Rows;

                DataRowCollection currentPageRows = currentPageData.Rows;
                currentPageRows.Clear();

                for (int i = lowerLimit; i < upperLimit; i++)
                {
                    currentPageData.ImportRow(rows[i]);
                }

                return currentPage;
            }
            else
            {
                return -1;
            }
        }

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
                    currentPageData.ImportRow(rows[i]);
                }

                return currentPage;
            }
            else
            {
                return -1;
            }
        }

        private void UpdatePageLimits()
        {
            dataCount = dataFiltered.Count;
            maxPage = (int)Math.Ceiling((dataCount + (0.0d)) / DataCountPerPage);
            lowerLimit = currentPage * DataCountPerPage - DataCountPerPage;
            upperLimit = (currentPage >= maxPage ? dataCount : lowerLimit + DataCountPerPage);
        }

        //Filtering and sorting

        public void FilterStringData(String columnName, String subString)//OK
        {
            dataFiltered.RowFilter = $"{columnName} LIKE \'%{subString}%'";
            currentPage = 1;
            RefreshData();
        }

        public void FilterIntegerData(String columnName, int from, int to)//OK
        {
            dataFiltered.RowFilter = $"{columnName} >= {from} AND {columnName} <= {to}";
            currentPage = 1;
            RefreshData();
        }

        public void FilterDoubleData(String columnName, double from, double to)//OK
        {
            dataFiltered.RowFilter = $"{columnName} >= {from} AND {columnName}<= {to}";
            currentPage = 1;
            RefreshData();
        }

        public void FilterBooleanData(String columnName, bool value)
        {
            dataFiltered.RowFilter = $"{columnName} = {value}";
            currentPage = 1;
            RefreshData();
        }

        public void FilterDateData(String columnName, DateTime from, DateTime to)//NOT WORKING
        {
            dataFiltered.RowFilter = $"{columnName} >= #{from.ToString()}# AND {columnName} <= #{to.ToString()}#";
            currentPage = 1;
            RefreshData();
        }

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

        public void ClearSortFiters()
        {
            dataFiltered.RowFilter = "";
            dataFiltered.Sort = "";
            currentPage = 1;
            RefreshData();
        }

    }
}


using System;
using System.Data;
using System.IO;

namespace HSA.Model
{
    public class DataSetManager
    {
        DataTable data;

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
            dataCount = data.Rows.Count;
            currentPage = 1;
            UpdatePageLimits();
            maxPage = (int) Math.Ceiling( (dataCount + (0.0d)) / DataCountPerPage);
            RefreshData();
        }

        private void LoadData()
        {
            //Reads file content
            string path = Directory.GetCurrentDirectory().Replace("HSA\\bin\\Debug", "data\\kc_house_data.csv");

            string[] rawData = File.ReadAllLines(path);

            //Adds columns
            string[] columnsNames = rawData[0].Split(',');
            for (int i = 0; i < columnsNames.Length; i++)
            {
                data.Columns.Add(columnsNames[i]);
                currentPageData.Columns.Add(columnsNames[i]);
            }

            //Adds rows
            for (int i = 1; i < rawData.Length; i++)
            {
                string[] row = rawData[i].Split(',');
                data.Rows.Add(row);
            }
        }

        private void RefreshData()
        {
            UpdatePageLimits();

            DataRowCollection rows = data.Rows;

            DataRowCollection currentPageRows = currentPageData.Rows;
            currentPageRows.Clear();

            for (int i = lowerLimit; i < upperLimit; i++)
            {
                currentPageData.ImportRow(rows[i]);
            }
        }

        public int NextPage()
        {
            if(currentPage < maxPage)
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
            lowerLimit = currentPage * DataCountPerPage - 250;
            upperLimit = (currentPage == maxPage ? dataCount : lowerLimit + DataCountPerPage + 1);
        }
    }
}

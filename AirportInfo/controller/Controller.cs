using AirportInfo.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportInfo.controller
{
    public abstract class Controller<T>
        where T : Base<T>
    {
        public DataTable dataTable = new DataTable();
        public BindingSource bindingSource = new BindingSource();
        public Dictionary<string, TextBox> TextBoxs = new Dictionary<string, TextBox>();
        public DataGridView dataGridView;
        public BindingNavigator bindingNavigator;
        //public BindingNavigator bindingNavigator;

        public Controller() { }
        public Controller(Dictionary<string, TextBox> textBoxs)
        {
            foreach (var item in textBoxs)
            {
                TextBoxs.Add(item.Key, item.Value);
            }
        }
        public Controller(DataGridView dgv)
        {
            dataGridView = dgv;
            bindingSource.DataSource = dataTable;
            dataGridView.DataSource = bindingSource;
        }
        public Controller(DataGridView dgv, BindingNavigator bn)
        {
            
             dataGridView = dgv;
            //bindingNavigator = bn;
            bindingSource.DataSource = dataTable;
            dataGridView.DataSource = bindingSource;

            //bindingNavigator.BindingSource = bindingSource;
        }
      

        //метод формує стовпці таблиці
        public virtual void FillColumns()
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataColumn column;
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                dataTable.Columns.Add(column);
            }
            //dataGridView.Columns["ID"].Visible = false;
        }
        public void FillRows(T[] array)
        {
            if (dataTable.Rows.Count > 0)
                dataTable.Rows.Clear();
            for (int i = 0; i < array.Length; i++)
                AddRow(array[i]);
        }
        public virtual void AddRow(T currentrow)
        {
            Type myType = typeof(T);//array[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataRow row = dataTable.NewRow();
            foreach (PropertyInfo prop in props)
            {
                row[prop.Name] = prop.GetValue(currentrow, null);
            }
            dataTable.Rows.Add(row);
        }
        public virtual int AddEmptyRow()
        {
            DataRow row = dataTable.NewRow();
            dataTable.Rows.Add(row);
            return dataTable.Rows.Count;
        }
        public abstract void LoadDB();


        public void FillDataTable(T[] array)
        {
            Type myType = array[0].GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            DataColumn column;
            DataRow row;
            // Додаємо стовпці таблиці
            foreach (PropertyInfo prop in props)
            {
                column = new DataColumn();
                column.DataType = prop.PropertyType;
                column.ColumnName = prop.Name;
                column.ReadOnly = true;
                dataTable.Columns.Add(column);
            }
            //Додаємо рядки таблиці
            for (int i = 0; i < array.Length; i++)
            {
                row = dataTable.NewRow();
                foreach (PropertyInfo prop in props)
                {
                    row[prop.Name] = prop.GetValue(array[i], null);
                }
                dataTable.Rows.Add(row);
            }
        }

        public void DrawDataTable(T[] array, DataGridView dgv)
        {
            dataTable = new DataTable();
            FillDataTable(array);
            //bindingSource.DataSource = dataTable;
            //dgv.DataSource = bindingSource;

        }

        public abstract void Save();

        public abstract void Delete();

    }
}

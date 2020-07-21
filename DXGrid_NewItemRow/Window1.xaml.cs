﻿using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace DXGrid_NewItemRow
{
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			this.DataContext = new MyViewModel();
		}


		private void TableView_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			// 可以选择性的添加初始值
			grid.SetCellValue(e.RowHandle, "UnitPrice", 10);
			grid.SetCellValue(e.RowHandle, "CompanyName", "newcompany");
			grid.SetCellValue(e.RowHandle, "Discontinued", false);
		}

		private void TableView_ValidateRow(object sender, GridRowValidationEventArgs e)
		{
			if (e.Row == null) return;
			if (e.RowHandle == GridControl.NewItemRowHandle)
			{
				e.IsValid = !string.IsNullOrEmpty(((Person)e.Row).ProductName);
				e.Handled = true;
			}
		}

		private void TableView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			if (e.RowHandle == GridControl.NewItemRowHandle)
			{
				e.ErrorText = "Please enter the Product name. ";
				e.WindowCaption = "Input Error";
			}
		}


		private void TableView_AddingNewRow(object sender, AddingNewEventArgs e)
		{
			e.NewObject = new Person(1);
		}
	}

	public class MyViewModel
	{
		public MyViewModel()
		{
			CreateList();

			PersonList.CollectionChanged += (s, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Add)
				{
					MessageBox.Show("添加了新项");

				}
			};

		}

		public ObservableCollection<Person> PersonList { get; set; }
		void CreateList()
		{
			PersonList = new ObservableCollection<Person>();
			for (int i = 0; i < 3; i++)
			{
				Person p = new Person(i);
				PersonList.Add(p);
			}

		}
	}
	public class Person
	{
		public Person() { }
		public Person(int i)
		{
			ProductName = "ProductName" + i;
			CompanyName = "CompanyName" + i;
			UnitPrice = i;
			Discontinued = i % 2 == 0;
		}

		public string ProductName { get; set; }

		public string CompanyName { get; set; }

		public int UnitPrice { get; set; }

		public bool Discontinued { get; set; }
	}
}

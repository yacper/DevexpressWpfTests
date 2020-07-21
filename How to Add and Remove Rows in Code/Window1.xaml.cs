using DevExpress.Xpf.Grid;
using System.Collections.ObjectModel;
using System.Windows;

namespace HowToAddAndRemoveRowsInCode {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }
        void addNewRow(object sender, RoutedEventArgs e) {
            view.AddNewRow();
            int newRowHandle = DataControlBase.NewItemRowHandle;
            grid.SetCellValue(newRowHandle, "ProductName", "New Product");
            grid.SetCellValue(newRowHandle, "UnitPrice", 10);
            grid.SetCellValue(newRowHandle, "CompanyName", "New Company");
            grid.SetCellValue(newRowHandle, "Discontinued", false);
        }
        void deleteRow(object sender, RoutedEventArgs e) {
            view.DeleteRow(view.FocusedRowHandle);
        }
    }

    public class MyViewModel {
        public MyViewModel() {
            CreateList();
        }

        public ObservableCollection<Person> PersonList { get; set; }
        void CreateList() {
            PersonList = new ObservableCollection<Person>();
            for (int i = 0; i < 3; i++) {
                Person p = new Person(i);
                PersonList.Add(p);
            }
        }
    }

    public class Person {
        public Person() { }
        public Person(int i) {
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

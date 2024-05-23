using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Student
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private StudentEntities db = new StudentEntities();

        public Window3()
        {
            InitializeComponent();
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            var student = db.Студенты.FirstOrDefault();
            if (student != null)
            {
                txtFIO.Text = student.ФИО;
                txtGender.Text = student.Пол;
                txtAddress.Text = student.Адрес;
                txtDateOfBirth.Text = student.Дата_рождения?.ToString() ?? string.Empty;
                txtPassportData.Text = student.Паспортные_данные;
                txtPhone.Text = student.Телефон;
                txtGroup.Text = student.Группа;
                txtRecordNumber.Text = student.Номер_зачетки.ToString();
                txtEnrollmentDate.Text = student.Дата_поступления.ToString();
                txtCourse.Text = student.Курс?.ToString() ?? string.Empty;


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текущего студента
            var currentStudent = db.Студенты.FirstOrDefault();

            // Если текущий студент не null, получаем следующего студента
            if (currentStudent != null)
            {
                var nextStudent = db.Студенты.Where(s => s.Код_студента > currentStudent.Код_студента).OrderBy(s => s.Код_студента).FirstOrDefault();


                // Если следующий студент существует, обновляем текстовые поля
                if (nextStudent != null)
                {
                    txtFIO.Text = nextStudent.ФИО;
                    txtGender.Text = nextStudent.Пол;
                    txtAddress.Text = nextStudent.Адрес;
         
                }
            }
        }
    }
}
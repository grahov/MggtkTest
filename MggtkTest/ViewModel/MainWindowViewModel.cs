using MggtkTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MggtkTest.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _name;
        private int _course;
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private Student _newStudent;

        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value, nameof(Name));
        }

        public int Course
        {
            get => _course;
            set => SetPropertyChanged(ref _course, value, nameof(Course));
        }

        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetPropertyChanged(ref _students, value, nameof(Students));
        }

        public Student SelectedStudent
        {
            get => _selectedStudent;
            set => SetPropertyChanged(ref _selectedStudent, value, nameof(SelectedStudent));
        }

        public Student NewStudent
        {
            get => _newStudent;
            set => SetPropertyChanged(ref _newStudent, value, nameof(NewStudent));
        }
        

        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Student>();
            NewStudent = new Student();
        }

        public MainWindowViewModel(Student student)
        {
            Students = new ObservableCollection<Student>();
            NewStudent = student;
        }

        public async void LoadStudent()
        {
            Students.Clear();
            using(var context = new CollegeEntities())
            {
                var temp = await context.Student.ToListAsync();

                var selectedStudent = (from student in context.Student
                                      select student).ToList();

                foreach (var student in temp)
                {
                    if (student.IsDeleted == true)
                    {
                        continue;
                    }

                    Students.Add(student);
                }
            }
        }

        public async void DeleteStudent()
        {
            try
            {
                using (var context = new CollegeEntities())
                {
                    var findEntity = await context.Student.FirstOrDefaultAsync(s => s.Id == SelectedStudent.Id);
                    if (findEntity == null)
                        return;
                    var result = context.Student.Remove(findEntity);
                    await context.SaveChangesAsync();

                    LoadStudent();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        public async Task<bool> AddOrEditStudent()
        {

            using (var context = new CollegeEntities())
                {
                    var findStudent = await context.Student.FirstOrDefaultAsync(s => s.Id == NewStudent.Id);
                if (findStudent != null)
                {
                    findStudent.Name = NewStudent.Name;
                    findStudent.Course = NewStudent.Course;
                }
                else
                {
                    var newStudent = context.Student.Add(NewStudent);
                }
                    
                    await context.SaveChangesAsync();
                    return true;
                }
            
        }
    }
}
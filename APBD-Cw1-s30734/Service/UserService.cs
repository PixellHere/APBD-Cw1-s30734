using APBD_Cw1_s30734.Models;

namespace APBD_Cw1_s30734.Service;

public class UserService
{
    public void AddNewEmployee(string firstName, string lastName, string role, int salary)
    {
        Employee newEmployee = new Employee(firstName, lastName, role, salary);
        User.Users.Add(newEmployee);
    }

    public void AddNewStudent(string firstName, string lastName, int semester, string major)
    {
        Student newStudent = new Student(firstName, lastName, semester, major);
        User.Users.Add(newStudent);
    }

    public void DeleteUser(string uuid)
    {
        int index = User.Users.FindIndex(u => u.Uuid == uuid);

        if (index != -1)
        {
            User.Users.RemoveAt(index);
        }
    }
}
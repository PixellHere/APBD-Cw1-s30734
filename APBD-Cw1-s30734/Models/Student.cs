namespace APBD_Cw1_s30734.Models;

public class Student : User
{
    public static int MaxActiveRentals = 2;
    
    int _semester;
    string _major;

    public Student(string firstName, string lastName, int semester, string major) : base(firstName, lastName, APBD_Cw1_s30734.Models.UserType.Student)
    {
        _semester = semester;
        _major = major;
    }
}
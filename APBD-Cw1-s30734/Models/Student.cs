namespace APBD_Cw1_s30734;

public class Student : User
{
    int _semester;
    string _major;

    public Student(string firstName, string lastName, int semester, string major) : base(firstName, lastName, APBD_Cw1_s30734.UserType.Student)
    {
        _semester = semester;
        _major = major;
    }
}
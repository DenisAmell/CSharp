using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1;

public sealed class Student :
        IEquatable<Enum>,
        IEquatable<Student>,
        IEquatable<object>
{
    public enum Course
    {
        CSharp,
        GO,
        Yandex,
        DataSet,
        InfrastructureActivities

    }

    private readonly string? _surname;
    private readonly string? _name;
    private readonly string? _patronymic;
    private readonly string? _number_group;
    private readonly Course _course;

    public int GetNumberGourse { get; }

    public Student(string? surname, string? name, string? patronymic, string? number_group ,Course course)
    {
        _surname = surname ?? throw new ArgumentNullException(nameof(surname));
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        _number_group = number_group ?? throw new ArgumentNullException(nameof(number_group));
        _course = course;

        GetNumberGourse = _number_group[number_group.IndexOf('-') + 1] - '0';
    }

    public int GetNumberCourse
    {
        get
        {
            return GetNumberGourse;
        }
    }

    public string GetSurname => _surname;
    public string GetName => _name;

    public string GetPatronymic => _patronymic;
    public string GetNumberGroup => _number_group;

    public Course GetChosenCourse => _course;

    public override string ToString()
    {
        return $"[ Surname: {GetSurname}, Name: {GetName}, Patronumic: {GetPatronymic}, Number group: {GetNumberGroup}, Chosen Course: {GetChosenCourse}]";
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(_surname, _name, _patronymic, _number_group, _course);
    }

    public bool Equals(Student? @student)
    {
        if (@student == null) return false;

        return _surname.Equals(@student._surname, StringComparison.Ordinal) && _name.Equals(@student._name, StringComparison.Ordinal)
            && _patronymic.Equals(@student._patronymic, StringComparison.Ordinal) && _number_group.Equals(@student._number_group, StringComparison.Ordinal)
            && _course.Equals(@student._course);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        if(obj is Student @student)
        {
            return Equals(@student);
        }

        if (obj is Course @course)
        {
            return _course.Equals(@course);
        }

        return false;
    }

    public bool Equals(Enum? @enum)
    {
        if (@enum == null) return false;

        return _course.Equals(@enum);
    }

      bool IEquatable<object>.Equals(object? obj) {
        if (obj == null) return false;

        if (obj is Student @student)
        {
            return Equals(@student);
        }

        if (obj is Course @course)
        {
            return _course.Equals(@course);
        }

        return false;
    }


}


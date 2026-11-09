
namespace backend;

public class Date
{
    //fields
    private int _year;
    private int _month;
    private int _day;

    //constructors
    public Date()
    {
        _year = 1900;
        _month = 1;
        _day = 1;
    }

    public Date(int year, int month, int day)
    {
        _year = year;
        _month = month;
        _day = day;

    }

    //properties

    public override string ToString()
    {
        return $"{_year}/{_month}/{_day}" ;
    }




    //publi methods



    //private methods
}

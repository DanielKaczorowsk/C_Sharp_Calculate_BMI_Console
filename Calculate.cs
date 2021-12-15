interface czlowiek
{
    int wiek { get; set; }
    float waga{ get ; set; }
    float wzrost { get; set; }
    double BMI { get; set; }
    string dane { get; set; }
    void wyswietlenie();
}
interface calculator_czlowiek
{
    void calculator(czlowiek dane);
    double sum { get; set; }
}
interface parser_czlowiek
{
    string text { get; set; }
    double wynik { get; set; }
    void parser();
}
class Facet:czlowiek
{
    private int _wiek;
    private float _waga;
    private float _wzrost;
    private double _bmi;
    private string _dane;
    public int wiek
    {
        get => _wiek;
        set => _wiek = value;
    }
    public float waga
    {
        get => _waga;
        set => _waga = value;
    }
    public float wzrost
    {
        get => _wzrost;
        set => _wzrost = value;
    }
    public double BMI
    {
        get => _bmi;
        set => _bmi = value;
    }
    public string dane
    {
        get => _dane;
        set => _dane = value;
    }
    public void wyswietlenie()
    {
        Console.WriteLine(dane);
    }
}
class Kobieta : czlowiek
{
    private int _wiek;
    private float _waga;
    private float _wzrost;
    private double _bmi;
    private string _dane;
    public int wiek
    {
        get => _wiek;
        set => _wiek = value;
    }
    public float waga
    {
        get => _waga;
        set => _waga = value;
    }
    public float wzrost
    {
        get => _wzrost;
        set => _wzrost = value;
    }
    public double BMI
    {
        get => _bmi;
        set => _bmi = value;
    }
    public string dane
    {
        get => _dane;
        set => _dane = value;
    }
    public void wyswietlenie()
    {
        Console.WriteLine(dane);
    }
}
class calculate_bmi : calculator_czlowiek
{
    private double _sum;
    public double sum
    {
        get => _sum;
        set => _sum = value;
    }
    public void calculator(czlowiek dane)
    {
        sum=dane.waga / Math.Pow(dane.wzrost, 2);
        dane.BMI = sum;
    }
}
class parser_dane : parser_czlowiek
{
    private string _text;
    private double _wynik;
    public string text
    {
        get => _text;
        set => _text = value;
    }
    public double wynik
    {
        get => _wynik;
        set => _wynik = value;
    }
    public void parser()
    {
        text = wynik.ToString();

    }
}
class contex
{
    private calculator_czlowiek calc;
    private czlowiek dane;
    public contex(calculator_czlowiek calc)
    {
        this.calc = calc;
    }
    public void calculate(czlowiek dane)
    {
        this.dane = dane;
        dane.wiek = 20;
        dane.waga = 78;
        dane.wzrost = 1.80F;
        this.calc.calculator(dane);
    }
    public void parser(parser_czlowiek parser)
    {
        parser.wynik = this.calc.sum;
        parser.parser();
        this.dane.dane = parser.text;
    }
}
class contoller
{
    static void Main()
    {
        var czlowiek = new Facet();
        contex strategy = new contex(new calculate_bmi());
        strategy.calculate(czlowiek);
        strategy.parser(new parser_dane());
        czlowiek.wyswietlenie();

    }
}

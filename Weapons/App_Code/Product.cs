using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// </summary>
public class Product
{

    public string Name { get; set; }
    public string Img { get; set; }
    public string Desc { get; set; }
    public int Id { get; set; }

    public Product(int id,string name, string desc, string img)
    {
        id = id;
        Name = name;
        Img = img;
        Desc = desc;

    }
}
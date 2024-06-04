using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqToSqlEquijoin
{
  class Program
  {
    static void Main(string[] args)
    {
      Publishers publishers = new Publishers();

      var titles = from title in publishers.Titles
                   join titleAuthor in publishers.TitleAuthors on 
                   title.TitleID equals titleAuthor.TitleID
                   join author in publishers.Authors on 
                   titleAuthor.AuthorID equals author.AuthorID 
                   select new 
                   {
                     Author=author.FirstName + ' ' + author.LastName,
                     Book=title.BookTitle
                   };

      Array.ForEach(titles.ToArray(), b=>
        Console.WriteLine("Author: {0}, Book: {1}", b.Author, b.Book));
  
      Console.ReadLine();
    }
  }



  public class Publishers : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=pubs;Integrated Security=True";

    public Publishers() : base(connectionString)
    {
      Log = Console.Out;
    }

    public Table<Author> Authors
    {
      get{ return this.GetTable<Author>(); }
    }
    
    public Table<TitleAuthor> TitleAuthors
    {
      get{ return this.GetTable<TitleAuthor>(); }
    }

    public Table<Title> Titles
    {
      get{ return this.GetTable<Title>(); }
    }
  }

  [Table(Name="authors")]
  public class Author 
  {
    [Column(Name="au_id", IsPrimaryKey=true)]
    public int AuthorID{ get; set; }

    [Column(Name="au_lname")]
    public string LastName{ get; set; }

    [Column(Name="au_fname")]
    public string FirstName{ get; set; }

    [Column(Name="phone")]
    public string Phone{ get; set; }

    [Column(Name="address")]
    public string Address{ get; set; }

    [Column(Name="city")]
    public string City{ get; set; }

    [Column(Name="state")]
    public string State{ get; set; }

    [Column(Name="zip")]
    public string ZipCode{ get; set; }

    [Column(Name="contract")]
    public bool? Contract{ get; set; }
  }

  [Table(Name="titleauthor")]
  public class TitleAuthor
  {
    [Column(Name="au_id")]
    public int? AuthorID{ get; set; }

    [Column(Name="title_id")]
    public int? TitleID{ get; set; }

    [Column(Name="au_ord")]
    public Int16? AuthorOrder{ get; set; }

    [Column(Name="royaltyper")]
    public int? RoyaltyPercentage{ get; set; }
  }

  [Table(Name="titles")]
  public class Title
  {
    [Column(Name="title_id", IsPrimaryKey=true)]
    public int? TitleID{ get; set; }

    [Column(Name="title")]
    public string BookTitle{ get; set; }

    [Column(Name="type")]
    public string Type{ get; set; }

    [Column(Name="pub_id")]
    public string PublisherID{ get; set; }

    [Column(Name="price")]
    public decimal? Price{ get; set; }

    [Column(Name="advance")]
    public decimal? Advance{ get; set; }

    [Column(Name="royalty")]
    public int? Royalty{ get; set; }

    [Column(Name="ytd_sales")]
    public int? YearToDateSales{ get; set; }

    [Column(Name="notes")]
    public string Notes{ get; set; }

    [Column(Name="pubdate")]
    public DateTime? PublicationDate{ get; set; }
  }
}

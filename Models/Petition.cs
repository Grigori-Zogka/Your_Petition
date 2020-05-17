
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

/**
  * in this model we define the properties of the petitions and difine the requirements that the user needs to input 
  * in order to create a petition
  * */


namespace Your_Petition.Models
{
    public class Petition { 
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Please give your Petition a Title")]
    public string Title { get; set; }

    [StringLength(250, MinimumLength = 3)]
    [Required(ErrorMessage = "Please provide details for the petition")]
    public string Discription { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Please provide a general category for the petition")]
    public string Category { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Please type your user name")]
    public string OwnerName { get; set; }

}

/**
 * PetitionDBContext classs represents the Entity framework Petition database, handling the fetching, storing and updating
 * Petition class instances in the database
 * */
public class PetitionDBContext : DbContext
{
    public DbSet<Petition> Petitons { get; set; }

}

}
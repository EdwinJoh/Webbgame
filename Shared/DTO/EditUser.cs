using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace SharedHelpers.DTO;

public class EditUser
{

    [Required]
    public string GamerTag { get; set; }

    public EditUser()
    {
    }

    public EditUser(User user)
    {
        GamerTag = user.GameTag;
    }
}


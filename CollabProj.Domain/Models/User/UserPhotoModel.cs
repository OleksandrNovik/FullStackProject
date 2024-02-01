using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollabProj.Domain.Models.User
{
    /// <summary>
    /// User's photo Model
    /// </summary>
    public class UserPhotoModel
    {
        /// <summary>
        /// URL of the user photo.
        /// </summary>
        public string PhotoURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoDotNet.Models.Repositories.Validations
{
   public class TagValidator
   {
       private readonly TagRepository _tagRepository;

       public TagValidator(DbContext context)
       {
           _tagRepository = new TagRepository(context);
       }
       public bool ValidateName(string name)
       {
           var tag = _tagRepository.GetAllTags().FirstOrDefault(a => a.Name == name);

            if (tag != null) return true;

            return false; 
       }
    }
}

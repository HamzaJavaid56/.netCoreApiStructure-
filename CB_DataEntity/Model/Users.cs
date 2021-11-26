using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CB_DataEntity.Model
{
   public class Users
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public Boolean is_locked_out { get; set; }
        public string failed_password_attempt_count { get; set; }
        public Boolean is_active { get; set; }
        public Boolean deleted { get; set; }
    }

    public class UsersRequest
    {
        [Key]
        public int user_id { get; set; }
        public string password { get; set; }
    }
}

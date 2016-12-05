using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace ComunityConnect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestService.svc or RestService.svc.cs at the Solution Explorer and start debugging.
    public class RestService : IRestService
    {

        public bool DeleteUser(int UserID)
        {
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                //Create the student stud object
                CCtblUser User = new CCtblUser();
                try
                {
                    User = entities.CCtblUsers.Find(UserID);
                    //Delete a record
                    entities.CCtblUsers.Remove(User);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool DeleteEvent(int EventID)
        {
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                //Create the student stud object
                CCtblEvent User = new CCtblEvent();
                try
                {
                    User = entities.CCtblEvents.Find(EventID);
                    //Delete a record
                    entities.CCtblEvents.Remove(User);
                    entities.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public CCtblUser ReadUser(int UserID)
        {
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                CCtblUser stud = new CCtblUser();
                stud = entities.CCtblUsers.Find(UserID);
                return stud;
            }
        }


        public CCtblEvent[] ReadEventList()
        {
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                var events = from s in entities.CCtblEvents select s;
                return events.ToArray();
            }
        }


        public string CreateUserPost(CCtblUser CreateUser)
        {
            //try
            //{
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                entities.CCtblUsers.Add(CreateUser);
                entities.SaveChanges();
                if (CreateUser.fldUserNo > 0)
                    return CreateUser.fldUserNo.ToString();
                else
                    return "false";
            }
        }

        public string CreateGuestPost(CCtblGuestLookUp guest)
        {
            using (ist420grp7Entities entities = new ist420grp7Entities())
            {
                entities.CCtblGuestLookUps.Add(guest);
                entities.SaveChanges();
                if (guest.fldEntryNo > 0)
                    return guest.fldEntryNo.ToString();
                else
                    return "false";
            }
        }







        //public string CreateUserPost(CCtblUser user)
        //{
        //    using (ist420grp7Entities entities = new ist420grp7Entities())
        //    {
        //        entities.CCtblUsers.Add(user);
        //        entities.SaveChanges();
        //        if (user.fldUserNo > 0)
        //            return user.fldUserNo.ToString();
        //        else
        //            return "false";
        //    }

        //}
    }
}
    

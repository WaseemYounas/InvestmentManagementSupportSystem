using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.DAL
{
    public class UserDAL
    {
        DataContext db;
        #region User
        public List<User> getUsersList()
        {
            List<User> users;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            users = db.User.ToList();
            //}

            return users;
        }

        public User getUserById(int _Id)
        {
            User user;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            user = db.User.FirstOrDefault(x => x.userId == _Id);
            //}

            return user;
        }

        public bool AddUser(User _user)
        {
            using (db = new DataContext())
            {
                db.User.Add(_user);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateUser(User _user)
        {
            using (db = new DataContext())
            {
                db.Entry(_user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        public bool DeleteUser(User obj)
        {
            using (db = new DataContext())
            {
                User _user = db.User.Where(x => x.userId == obj.userId).FirstOrDefault();
                db.User.Remove(_user);
                db.SaveChanges();

            }
            return true;
        }
        #endregion

        #region Role
        public List<Role> getRolesList()
        {
            List<Role> Roles;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Roles = db.Role.ToList();
            //}

            return Roles;
        }

        public Role getRoleById(int _Id)
        {
            Role Role;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Role = db.Role.FirstOrDefault(x => x.roleId == _Id);
            //}

            return Role;
        }

        public bool AddRole(Role _Role)
        {
            using (db = new DataContext())
            {
                db.Role.Add(_Role);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateRole(Role _Role)
        {
            using (db = new DataContext())
            {
                db.Entry(_Role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        public bool DeleteRole(Role obj)
        {
            using (db = new DataContext())
            {
                Role _user = db.Role.Where(x => x.roleId == obj.roleId).FirstOrDefault();
                db.Role.Remove(_user);
                db.SaveChanges();

            }
            return true;
        }
        #endregion

        #region Idea
        public List<Idea> getIdeasList()
        {
            List<Idea> Ideas;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Ideas = db.Idea.ToList();
            //}

            return Ideas;
        }

        public Idea getIdeaById(int _Id)
        {
            Idea Idea;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Idea = db.Idea.FirstOrDefault(x => x.ideaId == _Id);
            //}

            return Idea;
        }

        public bool AddIdea(Idea _Idea)
        {
            using (db = new DataContext())
            {
                db.Idea.Add(_Idea);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateIdea(Idea _Idea)
        {
            using (db = new DataContext())
            {
                db.Entry(_Idea).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        public bool DeleteIdea(Idea obj)
        {
            using (db = new DataContext())
            {
                Idea _user = db.Idea.Where(x => x.ideaId == obj.ideaId).FirstOrDefault();

                db.Idea.Remove(_user);
                db.SaveChanges();

            }
            return true;
        }
        #endregion

        #region Request
        public List<Request> getRequestsList()
        {
            List<Request> Requests;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Requests = db.Request.ToList();
            //}

            return Requests;
        }

        public Request getRequestById(int _Id)
        {
            Request Request;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Request = db.Request.FirstOrDefault(x => x.reqId == _Id);
            //}

            return Request;
        }

        public bool AddRequest(Request _Request)
        {
            using (db = new DataContext())
            {
                db.Request.Add(_Request);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateRequest(Request _Request)
        {
            using (db = new DataContext())
            {
                db.Entry(_Request).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        public bool DeleteRequest(Request obj)
        {
            using (db = new DataContext())
            {
                Request _user = db.Request.Where(x => x.reqId == obj.reqId).FirstOrDefault();

                db.Request.Remove(_user);
                db.SaveChanges();

            }
            return true;
        }
        #endregion

        #region Appointment
        public List<Appointment> getAppointmentsList()
        {
            List<Appointment> Appointments;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Appointments = db.Appointment.ToList();
            //}

            return Appointments;
        }

        public Appointment getAppointmentById(int _Id)
        {
            Appointment Appointment;
            db = new DataContext();
            //using (db = new timecardEntities())
            //{
            Appointment = db.Appointment.FirstOrDefault(x => x.appId == _Id);
            //}

            return Appointment;
        }

        public bool AddAppointment(Appointment _Appointment)
        {
            using (db = new DataContext())
            {
                db.Appointment.Add(_Appointment);
                db.SaveChanges();
            }
            return true;
        }

        public bool UpdateAppointment(Appointment _Appointment)
        {
            using (db = new DataContext())
            {
                db.Entry(_Appointment).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }
        public bool DeleteAppointment(Appointment obj)
        {
            using (db = new DataContext())
            {
                db.Appointment.Remove(obj);
                db.SaveChanges();

            }
            return true;
        }
        #endregion
    }
}
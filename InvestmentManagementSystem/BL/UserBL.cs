using InvestmentManagementSystem.DAL;
using InvestmentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentManagementSystem.BL
{
    public class UserBL
    {
        #region User
        public List<User> getUserList()
        {
            return new UserDAL().getUsersList().Where(x=>x.isActive!=-1).ToList();
        }

        public User getUserById(int _id)
        {
            return new UserDAL().getUserById(_id);
        }

        public bool AddUser(User _user)
        {
            if (_user.name == null || _user.email == null ||  _user.password == null )
                return false;
            return new UserDAL().AddUser(_user);
        }

        public bool UpdateUser(User _user)
        {
            //if (_user.FirstName == null || _user.LastName == null || _user.Email == null || _user.Password == null)
            

            return new UserDAL().UpdateUser(_user);
        }
        public bool DeleteUser(User _user)
        {
            //if (_user.FirstName == null || _user.LastName == null || _user.Email == null || _user.Password == null)


            return new UserDAL().DeleteUser(_user);
        }
        #endregion
        #region Role
        public List<Role> getRoleList()
        {
            return new UserDAL().getRolesList();
        }

        public Role getRoleById(int _id)
        {
            return new UserDAL().getRoleById(_id);
        }

        public bool AddRole(Role _Role)
        {
            if (_Role.roleName == null)
                return false;
            return new UserDAL().AddRole(_Role);
        }

        public bool UpdateRole(Role _Role)
        {
            return new UserDAL().UpdateRole(_Role);
        }
        public bool DeleteRole(Role _Role)
        {
            return new UserDAL().DeleteRole(_Role);
        }
        #endregion
        #region Idea
        public List<Idea> getIdeaList()
        {
            return new UserDAL().getIdeasList();
        }

        public Idea getIdeaById(int _id)
        {
            return new UserDAL().getIdeaById(_id);
        }

        public bool AddIdea(Idea _Idea)
        {
            if (_Idea.title == null || _Idea.description == null || _Idea.amount.ToString() == null)
                return false;
            return new UserDAL().AddIdea(_Idea);
        }

        public bool UpdateIdea(Idea _Idea)
        {
            //if (_Idea.FirstName == null || _Idea.LastName == null || _Idea.Email == null || _Idea.Password == null)


            return new UserDAL().UpdateIdea(_Idea);
        }
        public bool DeleteIdea(int Id)
        {
            //if (_Idea.FirstName == null || _Idea.LastName == null || _Idea.Email == null || _Idea.Password == null)
            Idea idea = getIdeaById(Id);

            return new UserDAL().DeleteIdea(idea);
        }
        #endregion

        #region Request
        public List<Request> getRequestList()
        {
            return new UserDAL().getRequestsList().ToList();
        }

        public Request getRequestById(int _id)
        {
            return new UserDAL().getRequestById(_id);
        }

        public bool AddRequest(Request _Request)
        {
            if (_Request.senderId.ToString() == null || _Request.incubatorId.ToString() == null || _Request.ideaId.ToString() == null)
                return false;
            return new UserDAL().AddRequest(_Request);
        }

        public bool UpdateRequest(Request _Request)
        {
            //if (_Request.FirstName == null || _Request.LastName == null || _Request.Email == null || _Request.Password == null)


            return new UserDAL().UpdateRequest(_Request);
        }
        public bool DeleteRequest(Request _Request)
        {
            //if (_Request.FirstName == null || _Request.LastName == null || _Request.Email == null || _Request.Password == null)


            return new UserDAL().DeleteRequest(_Request);
        }
        #endregion

        #region Appointment
        public List<Appointment> getAppointmentList()
        {
            return new UserDAL().getAppointmentsList();
        }

        public Appointment getAppointmentById(int _id)
        {
            return new UserDAL().getAppointmentById(_id);
        }

        public bool AddAppointment(Appointment _Appointment)
        {
            if (_Appointment.senderId.ToString() == null|| _Appointment.ideaId.ToString() == null)
                return false;
            return new UserDAL().AddAppointment(_Appointment);
        }

        public bool UpdateAppointment(Appointment _Appointment)
        {
            return new UserDAL().UpdateAppointment(_Appointment);
        }
        public bool DeleteAppointment(Appointment _Appointment)
        {
            return new UserDAL().DeleteAppointment(_Appointment);
        }
        #endregion
    }
}
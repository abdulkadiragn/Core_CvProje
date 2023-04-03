using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDAL messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            this.messageDAL = messageDAL;
        }
        public void TAdd(Message t)
        {
            messageDAL.Insert(t);
        }

        public void TDelete(Message t)
        {
            messageDAL.Delete(t);
        }

        public Message TGetById(int id)
        {
            return messageDAL.GetById(id);
        }

        public List<Message> TGetList()
        {
            return messageDAL.GetList();
        }

        public List<Message> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            messageDAL.Update(t);
        }
    }
}

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
    public class WriterMessageManager : IWriterMessageService
    {
        private readonly IWriterMessageDAL writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            this.writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetListReceiverMessage(string receiver)
        {
            return writerMessageDAL.GetbyFilter(x => x.Receiver == receiver);
        }

        public List<WriterMessage> GetListSendMessage(string send)
        {
            return writerMessageDAL.GetbyFilter(x => x.Sender == send);
        }

        public void TAdd(WriterMessage t)
        {
            writerMessageDAL.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            writerMessageDAL.Delete(t);
        }

        public WriterMessage TGetById(int id)
        {
            return writerMessageDAL.GetById(id);
        }

        public List<WriterMessage> TGetList()
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }
    }
}

using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class NotesBL:InotesBL
    {
        private readonly InotesRL inotesRL;

        public NotesBL(InotesRL inotesRL)
        {
            this.inotesRL = inotesRL;
        }

        public NotesModel CreateNote(NotesModel notesModel, long UserId)
        {
            try
            {
                return inotesRL.CreateNote(notesModel, UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetNote(long UserId)
        {
            try
            {
                return inotesRL.GetNotes(UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

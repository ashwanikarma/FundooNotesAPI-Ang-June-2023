using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface InotesRL
    {
        public NotesModel CreateNote(NotesModel notesModel, long UserId);

        public string GetNotes(long Userid);


    }
}

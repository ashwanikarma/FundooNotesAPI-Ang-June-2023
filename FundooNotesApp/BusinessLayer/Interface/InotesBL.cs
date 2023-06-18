using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface InotesBL
    {
        public NotesModel CreateNote(NotesModel notesModel, long UserId);
        public string GetNote(long UserId);
    }
}

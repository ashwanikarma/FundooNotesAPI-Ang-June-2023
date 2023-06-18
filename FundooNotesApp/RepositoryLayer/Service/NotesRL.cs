using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Service
{
    public class NotesRL:InotesRL
    {
        private readonly FundooContext fundooContext;
  

        public NotesRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }



        public NotesModel CreateNote(NotesModel notesModel, long UserId)
        {
            try
            {
                NotesEntity notesEntity = new NotesEntity();
                notesEntity.UserId = UserId;
                notesEntity.Title = notesModel.Title;
                notesEntity.Description = notesModel.Description;
                notesEntity.Color = notesModel.Color;
                notesEntity.Archive = notesModel.Archive;
                notesEntity.Trash = notesModel.Trash;
                notesEntity.Created = notesModel.Created;
                notesEntity.Updated = notesModel.Updated;
                notesEntity.Pin = notesModel.Pin;
                notesEntity.Image = notesModel.Image;
                fundooContext.notesEntities.Add(notesEntity);
                int result = fundooContext.SaveChanges();
                if (result != 0)
                {
                    return notesModel;
                }
                else { return null; }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetNotes(long Userid)
        {
            var result=fundooContext.notesEntities.Where(a=>a.UserId==Userid).Select(a=>new { a.Title, a.Description }).FirstOrDefault().ToString();
            if (result != null)
            {
                return result;
            }else return null;
        }
    }
}

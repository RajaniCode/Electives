
namespace SilverlightApplication1.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Ria;
    using System.Web.Ria.Data;
    using System.Web.DomainServices;
    using System.Data.Linq;
    using System.Web.DomainServices.LinqToSql;


    // Implements application logic using the MyNoteDataContext context.
    // TODO: Add your application logic to these methods or in additional methods.
    [EnableClientAccess()]
    public class MyNoteService : LinqToSqlDomainService<MyNoteDataContext>
    {

        // TODO: Consider
        // 1. Adding parameters to this method and constraining returned results, and/or
        // 2. Adding query methods taking different parameters.
        public IQueryable<Note> GetNotes()
        {
            return this.Context.Notes;
        }

        public void InsertNote(Note note)
        {
            this.Context.Notes.InsertOnSubmit(note);
        }

        public void UpdateNote(Note currentNote)
        {
            this.Context.Notes.Attach(currentNote, this.ChangeSet.GetOriginal(currentNote));
        }

        public void DeleteNote(Note note)
        {
            this.Context.Notes.Attach(note);
            this.Context.Notes.DeleteOnSubmit(note);
        }
    }
}



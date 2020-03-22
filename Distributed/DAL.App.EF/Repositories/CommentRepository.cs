﻿using Contracts.DAL.App.Repositories;
using DAL.Base.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CommentRepository : EFBaseRepository<Comment, AppDbContext>, ICommentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
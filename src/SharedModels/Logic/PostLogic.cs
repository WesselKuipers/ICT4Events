using System;
using System.Collections.Generic;
using SharedModels.Data.ContextInterfaces;
using SharedModels.Data.OracleContexts;
using SharedModels.Models;

namespace SharedModels.Logic
{
    public class PostLogic
    {
        private readonly IPostContext _context;
        private readonly IReportContext _reportContext;

        public PostLogic()
        {
            _context = new PostOracleContext();
            _reportContext = new ReportOracleContext();
        }

        public PostLogic(IPostContext context)
        {
            _context = context;
        }

        public Post InsertPost(Post post)
        {
            return _context.Insert(post);
        }

        public bool UpdatePost(Post post)
        {
            return _context.Update(post);
        }

        public bool DeletePost(Post post)
        {
            return _context.Delete(post);
        }

        public List<Post> GetAllByEvent(Event ev)
        {
            return _context.GetAllByEvent(ev);
        }

        public List<Reply> GetRepliesByPost(Post post)
        {
            return _context.GetRepliesByPost(post);
        }

        /// <summary>
        /// Adds a like to the a post
        /// </summary>
        /// <param name="guest">Guest that liked the post</param>
        /// <param name="post">Post that got liked</param>
        /// <returns>true if succesfull</returns>
        public bool Like(Guest guest, Post post)
        {
            // TODO: check if we need a LikeOracleContext for this (insert and delete queries are enough)
            return false;
        }

        /// <summary>
        /// Removes a like from a post
        /// </summary>
        /// <param name="guest">Guest that unliked the post</param>
        /// <param name="post">Post that got unliked</param>
        /// <returns>true if succesfull</returns>
        public bool UnLike(Guest guest, Post post)
        {
            // TODO
            return false;
        }

        /// <summary>
        /// Adds a report to a post
        /// </summary>
        /// <param name="guest">Guest that reported the post</param>
        /// <param name="post">Post that got reported</param>
        /// <param name="reason">Reason of guest to report the post</param>
        /// <returns>true if Report was successfully entered</returns>
        public bool Report(Guest guest, Post post, string reason)
        {
            var report = new Report(guest.ID, post.ID, reason, DateTime.Now);
            return (_reportContext.Insert(report) != null);
        }
    }
}

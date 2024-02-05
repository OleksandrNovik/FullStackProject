using CollabProj.Domain.Models.Content.TopicModels;

namespace CollabProj.Application.Interfaces.Services.ContentServices
{
    /// <summary>
    /// Interface to handle content pieces in topics 
    /// </summary>
    public interface ITopicContentService
    {
        /// <summary>
        /// Adds new content piece to a topic
        /// </summary>
        /// <param name="topicId"> Topic to add new piece on </param>
        /// <param name="data"> All data about content peice </param>
        /// <returns> Completed Task </returns>
        public Task NewContentPieceAsync(int topicId, ContentPieceModel data);

        /// <summary>
        /// Updates information about content piece
        /// </summary>
        /// <param name="contentPiece"> Updated data about contetn piece</param>
        /// <returns> Completed Task </returns>
        public Task UpdateContentPieceAsync(ContentPieceModel contentPiece);

        /// <summary>
        /// Deletes content piece by its Id
        /// </summary>
        /// <param name="pieceId"> Id of content piece that is deleted</param>
        /// <returns> Completed Task </returns>
        public Task DeleteContentPieceAsync(int pieceId);
    }
}

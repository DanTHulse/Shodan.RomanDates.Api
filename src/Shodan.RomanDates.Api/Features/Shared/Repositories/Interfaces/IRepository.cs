using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shodan.RomanDates.Api.Features.Shared.Repositories.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// Gets all entities for the given entity type of <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Be cautious when using this for larger datasets</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>An unordered and unfiltered list of <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetAllEntities<TEntity>()
            where TEntity : class;

        /// <summary>
        /// Gets all entities for the given entity type of <typeparamref name="TEntity"/> mapped to the type <typeparamref name="TModel"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Be cautious when using this for larger datasets</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <returns>An unordered and unfiltered list of <typeparamref name="TModel"/></returns>
        Task<IEnumerable<TModel>> GetAllEntities<TEntity, TModel>()
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Gets all entities for the given entity type of <typeparamref name="TEntity"/> filtered by the given query
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">A filter query on <typeparamref name="TEntity"/></param>
        /// <returns>An unordered, filtered list of <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetEntities<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class;

        /// <summary>
        /// Gets all entities for the given entity type of <typeparamref name="TEntity"/> filtered by the given query,
        /// mapped to the type <typeparamref name="TModel"/>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="query">A filter query on <typeparamref name="TEntity"/></param>
        /// <returns>An unordered, filtered list of <typeparamref name="TModel"/></returns>
        Task<IEnumerable<TModel>> GetEntities<TEntity, TModel>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Gets the first result that matches the provided query on <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">A filter query on <typeparamref name="TEntity"/></param>
        /// <returns>A single record of type <typeparamref name="TEntity"/></returns>
        Task<TEntity> GetEntity<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class;

        /// <summary>
        /// Gets the first result that matches the provided query on <typeparamref name="TEntity"/> mapped to the type <typeparamref name="TModel"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="query">A filter query on <typeparamref name="TEntity"/></param>
        /// <returns>A single record of type <typeparamref name="TEntity"/></returns>
        Task<TModel> GetEntity<TEntity, TModel>(Expression<Func<TEntity, bool>> query)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Updates the record in with the entity provided of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure that the Identifier of the record is present before updating.</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity that is to be updated</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpdateEntity<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Updates the record in with the entity provided of type <typeparamref name="TEntity"/>.
        /// <item>Takes an object of type <typeparamref name="TModel"/> and maps it to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure that the Identifier of the record is present before updating.</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="model">The model to be mapped to the entity</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpdateEntity<TEntity, TModel>(TModel model)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Updates all records in with the entity list provided of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure that the Identifiers of the records are present before updating.</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities to be updated</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpdateEntities<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        /// <summary>
        /// Updates all records in with the entity list provided of type <typeparamref name="TEntity"/>.
        /// <item>Takes objects of type <typeparamref name="TModel"/> and map them to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure that the Identifiers of the records are present before updating.</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="models">The models to be mapped to the entities</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpdateEntities<TEntity, TModel>(IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Updates all records by the query provided of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// To use this method, you need to provide both a filter query to find the entities you need to update,
        /// as well as an update function see below:
        /// <code>
        /// _ = <see langword="await"/> <see langword="this"/>._repo.UpdateEntities(o => o.IsDeleted == <see langword="false"/>, u =>
        /// {
        ///     u.IsDeleted = <see langword="true"/>;
        ///     <see langword="return"/> u;
        /// });
        /// </code>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The filter query to find records to update</param>
        /// <param name="update">The update function used to update the records, see example</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpdateEntities<TEntity>(Expression<Func<TEntity, bool>> query, Func<TEntity, TEntity> update)
            where TEntity : class;

        /// <summary>
        /// Inserts into the database the entity provided of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure the Identifier of the record is null</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity that is to be inserted</param>
        /// <returns>The newly created <typeparamref name="TEntity"/> and a flag indicating success</returns>
        Task<(bool success, TEntity entity)> InsertEntity<TEntity>(TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Inserts into the database the entity provided of type <typeparamref name="TEntity"/>.
        /// <item>Takes an object of type <typeparamref name="TModel"/> and map them to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure the Identifier of the record is null</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="model">The model to be mapped to the entity</param>
        /// <returns>The newly created <typeparamref name="TEntity"/> and a flag indicating success</returns>
        Task<(bool success, TEntity entity)> InsertEntity<TEntity, TModel>(TModel model)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Inserts into the database the entities provided of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure the Identifiers of the records are null</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entities">The entities that are to be inserted</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> InsertEntities<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class;

        /// <summary>
        /// Inserts into the database the entities provided of type <typeparamref name="TEntity"/>.
        /// <item>Takes objects of type <typeparamref name="TModel"/> and maps them to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure the Identifier of the record is null</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="models">The models to be mapped to the entities</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> InsertEntities<TEntity, TModel>(IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Upserts the entities of type <typeparamref name="TEntity"/> returned by the query, with the entities provided.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure the Identifiers of the records are present</item>
        /// <item>Be aware this method will delete all records found by the query</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query used to find and remove existing records</param>
        /// <param name="entities">The list of entities to be inserted</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpsertEntities<TEntity>(Expression<Func<TEntity, bool>> query, IEnumerable<TEntity> entities)
            where TEntity : class;

        /// <summary>
        /// Upserts the entities of type <typeparamref name="TEntity"/> returned by the query, with the entities provided.
        /// <item>Takes objects of type <typeparamref name="TModel"/> and maps them to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure the Identifiers of the records are not present</item>
        /// <item>Be aware this method will delete all records found by the query</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="query">The query used to find and remove existing records</param>
        /// <param name="models">The list of models to be mapped to the entities</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpsertEntities<TEntity, TModel>(Expression<Func<TEntity, bool>> query, IEnumerable<TModel> models)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Upserts the entity of type <typeparamref name="TEntity"/> returned by the query, with the entity provided.
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>Please ensure the Identifier of the record is not present</item>
        /// <item>Be aware this method will delete all records found by the query</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query used to find and remove existing records</param>
        /// <param name="entity">The entity to be inserted</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpsertEntity<TEntity>(Expression<Func<TEntity, bool>> query, TEntity entity)
            where TEntity : class;

        /// <summary>
        /// Upserts the entity of type <typeparamref name="TEntity"/> returned by the query, with the model provided.
        /// <item>Takes an object of type <typeparamref name="TModel"/> and map it to <typeparamref name="TEntity"/></item>
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>A valid Automapper profile needs to exist between these two classes</item>
        /// <item>Please ensure the Identifier of the record is not present</item>
        /// <item>Be aware this method will delete all records found by the query</item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TModel">The type of the model to be mapped to.</typeparam>
        /// <param name="query">The query used to find and remove existing records</param>
        /// <param name="model">The model to be mapped to the entity</param>
        /// <returns>True if operation is successful</returns>
        Task<bool> UpsertEntity<TEntity, TModel>(Expression<Func<TEntity, bool>> query, TModel model)
            where TEntity : class
            where TModel : class;

        /// <summary>
        /// Provides a count of entities of type <typeparamref name="TEntity"/> by the query provided
        /// </summary>
        /// <remarks>
        /// <list type="bullet"><item>This will only provide a count, if you need the models as well use <see cref="GetEntities{TEntity}(Expression{Func{TEntity, bool}})"/></item></list>
        /// </remarks>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query used when performing the count</param>
        /// <returns>A count of entities by the query</returns>
        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : class;
    }
}

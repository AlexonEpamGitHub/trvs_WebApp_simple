using System;
using System.Collections.Generic;
using System.Linq;
using NewApp.Models;
using Microsoft.Extensions.Logging;

namespace NewApp.Services
{
    public interface IExampleService
    {
        IEnumerable<ExampleModel> GetAllExamples();
        ExampleModel GetExampleById(int id);
        void AddExample(ExampleModel example);
        void UpdateExample(int id, ExampleModel example);
        void DeleteExample(int id);
    }

    public class ExampleService : IExampleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ExampleService> _logger;

        public ExampleService(ApplicationDbContext dbContext, ILogger<ExampleService> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<ExampleModel> GetAllExamples()
        {
            try
            {
                _logger.LogInformation("Fetching all examples.");
                return _dbContext.Examples.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching examples.");
                throw;
            }
        }

        public ExampleModel GetExampleById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching example with ID {id}.");
                return _dbContext.Examples.FirstOrDefault(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching example with ID {id}.");
                throw;
            }
        }

        public void AddExample(ExampleModel example)
        {
            try
            {
                if (example == null) throw new ArgumentNullException(nameof(example));
                _logger.LogInformation("Adding a new example.");
                _dbContext.Examples.Add(example);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new example.");
                throw;
            }
        }

        public void UpdateExample(int id, ExampleModel example)
        {
            try
            {
                if (example == null) throw new ArgumentNullException(nameof(example));
                var existingExample = _dbContext.Examples.FirstOrDefault(e => e.Id == id);
                if (existingExample == null) throw new KeyNotFoundException($"Example with ID {id} not found.");

                _logger.LogInformation($"Updating example with ID {id}.");
                existingExample.Name = example.Name;
                existingExample.Description = example.Description;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating example with ID {id}.");
                throw;
            }
        }

        public void DeleteExample(int id)
        {
            try
            {
                var example = _dbContext.Examples.FirstOrDefault(e => e.Id == id);
                if (example == null) throw new KeyNotFoundException($"Example with ID {id} not found.");

                _logger.LogInformation($"Deleting example with ID {id}.");
                _dbContext.Examples.Remove(example);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting example with ID {id}.");
                throw;
            }
        }
    }
}

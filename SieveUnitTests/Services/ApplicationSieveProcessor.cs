using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using SieveUnitTests.Entities;

namespace SieveUnitTests.Services
{
	public class ApplicationSieveProcessor : SieveProcessor
    {
        private readonly IOptions<SieveOptions> _options;

        public ApplicationSieveProcessor(
            IOptions<SieveOptions> options,
            ISieveCustomSortMethods customSortMethods,
            ISieveCustomFilterMethods customFilterMethods)
            : base(options, customSortMethods, customFilterMethods)
        {
            _options = options;
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Post>(p => p.ThisHasNoAttributeButIsAccessible)
                .CanSort()
                .CanFilter()
                .HasName("shortname");

            mapper.Property<Post>(p => p.TopComment.Text)
                .CanFilter();

            mapper.Property<Post>(p => p.TopComment.Id)
                .CanSort();

            mapper.Property<Post>(p => p.OnlySortableViaFluentApi)
                .CanSort();

            return mapper;
        }

        
    }
}

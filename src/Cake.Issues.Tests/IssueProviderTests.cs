﻿namespace Cake.Issues.Tests
{
    using Cake.Testing;
    using Shouldly;
    using Testing;
    using Xunit;

    public sealed class IssueProviderTests
    {
        public sealed class TheCtor
        {
            [Fact]
            public void Should_Throw_If_File_Log_Is_Null()
            {
                // Given / When
                var result = Record.Exception(() => new FakeIssueProvider(null));

                // Then
                result.IsArgumentNullException("log");
            }

            [Fact]
            public void Should_Set_Log()
            {
                // Given
                var log = new FakeLog();

                // When
                var provider = new FakeIssueProvider(log);

                // Then
                provider.Log.ShouldBe(log);
            }
        }

        public sealed class TheReadIssuesMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var provider = new FakeIssueProvider(new FakeLog());

                // When
                var result = Record.Exception(() => provider.ReadIssues(IssueCommentFormat.PlainText));

                // Then
                result.IsInvalidOperationException("Initialize needs to be called first.");
            }
        }
    }
}

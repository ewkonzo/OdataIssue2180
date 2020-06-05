It's a modified version of https://github.com/xuzhg/WebApiSample/blob/master/IssuesOnWebApi/Issue2180/ i couldn't figure how to fork only code specific to the issue

It appears the issue rises only when the query is against a database... So i have added postgres(I am teribly sorry) to the original version I am unsure if the same will appear to other databases

Update the postgres connection string on ```Startup.cs``` the user should pe fairly powerful as the app will try to create its own database 

Then Run it, and you will get an error. I have already planted ```customers?$filter=Color%20in%20(%27Red%27,%27Blue%27)%20and%20id%20in%20(1)``` in launch.json

```System.InvalidCastException: Object must implement IConvertible.
   at System.Convert.ChangeType(Object value, Type conversionType, IFormatProvider provider)
   at System.Convert.ChangeType(Object value, Type conversionType)
   at Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter`2.Sanitize[T](Object value)
   at Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter`2.<>c__DisplayClass3_0`2.<SanitizeConverter>b__0(Object v)
   at Microsoft.EntityFrameworkCore.Storage.RelationalTypeMapping.CreateParameter(DbCommand command, String name, Object value, Nullable`1 nullable)
   at Microsoft.EntityFrameworkCore.Storage.Internal.TypeMappedRelationalParameter.AddDbParameter(DbCommand command, Object value)
   at Microsoft.EntityFrameworkCore.Storage.Internal.RelationalParameterBase.AddDbParameter(DbCommand command, IReadOnlyDictionary`2 parameterValues)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.CreateCommand(RelationalCommandParameterObject parameterObject, Guid commandId, DbCommandMethod commandMethod)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReaderAsync(RelationalCommandParameterObject parameterObject, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryingEnumerable`1.AsyncEnumerator.InitializeReaderAsync(DbContext _, Boolean result, CancellationToken cancellationToken)
   at Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.NpgsqlExecutionStrategy.ExecuteAsync[TState,TResult](TState state, Func`4 operation, Func`4 verifySucceeded, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
   at Microsoft.AspNetCore.Mvc.Infrastructure.AsyncEnumerableReader.ReadInternal[T](Object value)
   at Microsoft.AspNetCore.Mvc.Infrastructure.AsyncEnumerableReader.ReadInternal[T](Object value)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ObjectResultExecutor.ExecuteAsyncEnumerable(ActionContext context, ObjectResult result, Object asyncEnumerable, Func`2 reader)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeNextResultFilterAsync>g__Awaited|29_0[TFilter,TFilterAsync](ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.Rethrow(ResultExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.ResultNext[TFilter,TFilterAsync](State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.InvokeResultFilters()
--- End of stack trace from previous location where exception was thrown ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|19_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)
```



It's using 7.4.1 version but downgrading to 7.4.0 makes a this issue disapper.

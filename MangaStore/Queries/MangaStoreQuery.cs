﻿using GraphQL.Types;
using MangaStore.DataAccess;
using MangaStore.Types;
using MangaStore.Types.Book;

namespace MangaStore.Queries
{
    public class MangaStoreQuery : ObjectGraphType
    {
        public MangaStoreQuery(IUnitOfWork unitOfWork)
        {
            Field<ListGraphType<BookType>>(
                "books", 
                resolve: context => unitOfWork.Books.GetAll()
            );

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context => unitOfWork.Books.Get(context.GetArgument<int>("id"))
            );

            Field<ListGraphType<GenreType>>(
                "genres",
                resolve: context => unitOfWork.Genres.GetAll()
            );

            Field<GenreType>(
                "genre",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => unitOfWork.Genres.Get(context.GetArgument<int>("id"))
            );
        }
    }
}
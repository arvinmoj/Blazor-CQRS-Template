﻿using Application.WebUI.Shared.TodoLists;

namespace Application.Application.TodoLists;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<TodoList, TodoListDto>();
        CreateMap<TodoItem, TodoItemDto>();
    }
}

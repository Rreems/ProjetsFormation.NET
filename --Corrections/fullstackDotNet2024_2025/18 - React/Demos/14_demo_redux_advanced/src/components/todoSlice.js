import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { BASE_DB_URL } from "../firebaseConfig";
import axios from "axios";

export const fetchTodos = createAsyncThunk("todos/fetchTodos", async () => {
  const response = await axios.get(`${BASE_DB_URL}/todoList.json`);
  const data = await response.data;
  const todos = [];

  for (const key in data) {
    todos.push({ id: key, ...response.data[key] });
  }

  return todos;
});

export const postTodo = createAsyncThunk("todos/postTodo", async (newTodo) => {
  const response = await axios.post(`${BASE_DB_URL}/todoList.json`, newTodo);
  const data = await response.data;

  return {
    id: data.name,
    ...newTodo,
  };
});

const todoSlice = createSlice({
  name: "todos",
  initialState: {
    todos: [],
    isLoading: false,
  },
  reducers: {},
  /*
    .fullfilled => L'action se déclenche si la requête se termine
    .rejected => L'action se déclenche si la requête echoue
    .pending => l'action se déclenche pendant la requête
  */
  extraReducers: (builder) => {
    builder.addCase(fetchTodos.fulfilled, (state, action) => {
      state.todos = action.payload;
      console.log(action.payload);
    });
    builder.addCase(postTodo.fulfilled, (state, action) => {
      state.todos.push(action.payload);
      console.log(action.payload);
    });
    builder.addCase(fetchTodos.pending, (state, action) => {
      state.isLoading = true;
    });
  },
});

export default todoSlice.reducer;

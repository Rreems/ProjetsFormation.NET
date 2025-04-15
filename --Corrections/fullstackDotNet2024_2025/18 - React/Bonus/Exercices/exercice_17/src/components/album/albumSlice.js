import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { BASE_DB_URL } from "../../firebaseConfig.js";
import axios from "axios";

export const fetchAlbumsAction = createAsyncThunk(
  "albums/fetchAlbumsAction",
  async () => {
    const response = await axios.get(`${BASE_DB_URL}albums.json`);

    const data = await response.data;

    const tmpArray = [];

    for (const key in data) {
      tmpArray.push({ id: key, ...data[key] });
    }

    return tmpArray;
  }
);

export const deleteAlbumAction = createAsyncThunk(
  "albums/deleteAlbumAction",
  async (albumId) => {
    const token = localStorage.getItem("token");
    if (token) {
      const response = await axios.delete(
        `${BASE_DB_URL}albums/${albumId}.json?auth=${token}`
      );

      return albumId;
    }
  }
);

export const editAlbumAction = createAsyncThunk(
  "albums/editAlbumAction",
  async ({ id, ...album }) => {
    const token = localStorage.getItem("token");
    if (token) {
      const response = await axios.put(
        `${BASE_DB_URL}albums/${id}.json?auth=${token}`,
        album
      );

      const data = await response.data;

      return { id, ...data };
    }
  }
);

export const addAlbumAction = createAsyncThunk(
  "albums/addAlbumAction",
  async (album) => {
    const token = localStorage.getItem("token");
    if (token) {
      const response = await axios.post(
        `${BASE_DB_URL}albums.json?auth=${token}`,
        album
      );

      const data = await response.data;

      return { id: data.name, ...album };
    }
  }
);

const albumsSlice = createSlice({
  name: "albums",
  initialState: {
    albums: [],
    isLoading: false,
    formMode: "",
    error: null,
    selectedAlbum: null,
  },
  reducers: {
    setFormMode: (state, action) => {
      state.formMode = action.payload;
      console.log(state.formMode);
    },
    setSelectedAlbum: (state, action) => {
      state.selectedAlbum = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(fetchAlbumsAction.pending, (state) => {
      state.isLoading = true;
      state.error = null;
      state.albums = [];
    });

    builder.addCase(fetchAlbumsAction.rejected, (state, action) => {
      state.isLoading = false;
      state.error = action.payload;
    });

    builder.addCase(fetchAlbumsAction.fulfilled, (state, action) => {
      state.isLoading = false;
      state.albums = action.payload;
    });

    builder.addCase(deleteAlbumAction.fulfilled, (state, action) => {
      state.albums = state.albums.filter((a) => a.id !== action.payload);
    });

    builder.addCase(addAlbumAction.fulfilled, (state, action) => {
      state.albums.push(action.payload);
    });

    builder.addCase(editAlbumAction.fulfilled, (state, action) => {
      state.albums = [
        ...state.albums.filter((a) => a.id !== action.payload.id),
        action.payload,
      ];
    });
  },
});

export const { setFormMode, setSelectedAlbum } = albumsSlice.actions;
export default albumsSlice.reducer;

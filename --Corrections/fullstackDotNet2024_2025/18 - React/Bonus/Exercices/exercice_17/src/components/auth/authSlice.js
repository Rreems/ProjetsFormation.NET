import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { SIGN_IN_URL, SIGN_UP_URL } from "../../firebaseConfig";
import axios from "axios";

export const signInAction = createAsyncThunk(
  "auth/signInAction",
  async (credentials) => {
    const response = await axios.post(SIGN_IN_URL, credentials);

    const data = await response.data;

    return data;
  }
);

export const signUpAction = createAsyncThunk(
  "auth/signUpAction",
  async (credentials) => {
    const response = axios.post(SIGN_UP_URL, credentials);

    const data = await response.data;

    return data;
  }
);

const authSlice = createSlice({
  name: "auth",
  initialState: {
    authMode: "Se connecter",
    user: null,
  },
  reducers: {
    logOutAction(state, action) {
      state.user = null;
      localStorage.removeItem("token");
    },
    setAuthMode: (state, action) => {
      state.authMode = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder.addCase(signInAction.fulfilled, (state, action) => {
      state.user = action.payload;
      console.log(state.user);
      localStorage.setItem("token", action.payload.idToken);
    });

    builder.addCase(signUpAction.fulfilled, (state, action) => {
      state.user = action.payload;
      console.log(state.user);
      localStorage.setItem("token", action.payload.idToken);
    });
  },
});

export const { logOutAction, setAuthMode } = authSlice.actions;

export default authSlice.reducer;

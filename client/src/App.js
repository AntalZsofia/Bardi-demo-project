import React from "react";
import { Route, createBrowserRouter, createRoutesFromElements, RouterProvider } from "react-router-dom";

import Registration from './components/Registration';
import Login from './components/Login';

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path='/'>
      <Route path='/' element={<Registration />} />
      <Route path='/login' element={<Login />} />
    </Route>
  )
)

export default function App() {

  return (
    <div>
        <RouterProvider router={router} />
    </div>
  )
}
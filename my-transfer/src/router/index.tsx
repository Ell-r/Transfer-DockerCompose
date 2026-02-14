import {createBrowserRouter} from "react-router-dom";
import Home from "../pages/home/Home.tsx";
import Cities from "../pages/City/cities/Cities.tsx";
import App from "../App.tsx";
import Login from "../pages/login/Login.tsx";
import Register from "../pages/register/Register.tsx";
import Profile from "../pages/profile/Profile.tsx";
import AppLayout from "../admin/layout/AppLayout.tsx";
import CreateCountry from "../admin/pages/country/CreateCountry.tsx";
import DeleteCountry from "../admin/pages/country/DeleteCountry.tsx";
import UpdateCountry from "../admin/pages/country/UpdateCountry.tsx";
import CreateCity from "../admin/pages/city/CreateCity.tsx"
import AdminRoute from "../routes/AdminRoute.tsx"
import Countries from "../admin/pages/country/Countries.tsx"

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children: [
            { path: "", element: <Home /> },
            { path: "Cities/:id", element: <Cities /> },
            { path: "Login", element: <Login /> },
            { path: "Register", element: <Register /> },
            { path: "Profile", element: <Profile /> },

            {
                path: "admin",
                element: <AdminRoute />,
                children: [
                    {
                        element: <AppLayout />,
                        children: [
                            {index: true, element: <Countries /> },
                            { path: "create-country", element: <CreateCountry /> },
                            { path: "delete-country", element: <DeleteCountry /> },
                            { path: "update-country", element: <UpdateCountry /> },
                            { path: "create-city", element: <CreateCity /> },
                        ]
                    }
                ]
            }
        ]
    },
]);
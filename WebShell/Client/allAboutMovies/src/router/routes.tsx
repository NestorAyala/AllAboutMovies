import {createBrowserRouter, RouteObject} from "react-router-dom";
import App from "../App.tsx";
import MovieDetails from "../components/movies/MovieDetails.tsx";
import Movies from "../components/movies/Movies.tsx";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'createMovie', element: <MovieDetails key='create' /> },
            {path: 'editMovie/:id', element: <MovieDetails key='edit' /> },
            {path: '*', element: <Movies />}
        ]
    }
]

export const router = createBrowserRouter(routes);
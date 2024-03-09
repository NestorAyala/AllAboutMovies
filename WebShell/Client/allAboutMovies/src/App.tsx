import './App.css'
import Movies from "./components/movies/Movies.tsx";
import {Outlet, useLocation} from "react-router-dom";
import {Container} from "semantic-ui-react";
import {useEffect} from "react";
import {setupErrorHandlingInterceptor} from "./interceptors/axiosInterceptor.ts";

function App() {
    const location = useLocation();

    useEffect(() => {
        setupErrorHandlingInterceptor();
    }, []);
    
  return (
    <>
        {location.pathname === '/' ? <Movies /> : (
            <Container className="container-style">
                <Outlet/>
            </Container>
        )}
    </>
  )
}

export default App

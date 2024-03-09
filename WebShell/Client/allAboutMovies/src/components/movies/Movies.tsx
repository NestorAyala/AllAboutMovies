import {MovieDTO} from "../../models/movieDTO.ts";
import {useState, useEffect} from "react";
import apiConnector from "../../api/apiConnector.ts";
import MovieItem from "./MovieItem.tsx";
import {Button, Container} from "semantic-ui-react";
import {NavLink} from "react-router-dom";

export default function Movies()
{
    const [movies, setMovies] = useState<MovieDTO[]>([]);
    
    useEffect(() => {
        const fetchData = async () => {
            const fetchedMovies = await apiConnector.getMovies();
            setMovies(fetchedMovies);
        }
        
        fetchData();
    }, []);
    
    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style={{textAlign: 'center'}}>
                    <tr>
                        <th hidden={true}>Id</th>
                        <th>Title</th>
                        <th>Plot</th>
                        <th>Genre</th>
                        <th>Actors</th>
                        <th>Ratings</th>
                        <th>ReleaseDate</th>
                        <th>Actions</th>
                    </tr>
                    </thead>
                    <tbody>
                    {movies.length !== 0 && (
                        movies.map((movie, index) => (
                            <MovieItem key={index} movie={movie}/>
                        ))
                    )}
                    </tbody>
                </table>
                
                <Button as={NavLink} to="createMovie" floated="right" type="button" content="Add movie" positive/>
                
            </Container>
        </>
    )
}
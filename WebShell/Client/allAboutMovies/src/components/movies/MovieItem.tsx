import {MovieDTO} from "../../models/movieDTO.ts";
import apiConnector from "../../api/apiConnector.ts";
import {Button} from "semantic-ui-react";
import {NavLink} from "react-router-dom";

interface Props {
    movie: MovieDTO;
}

export default function MovieItem({movie}: Props)
{
    return (
        <>
            <tr className="center aligned">
                <td data-label="Id" hidden={true}>{movie.id}</td>
                <td data-label="Title">{movie.movieTitle}</td>
                <td data-label="Plot">{movie.moviePlot}</td>
                <td data-label="Genre">{movie.movieGenre}</td>
                <td data-label="Actors">{movie.movieActors}</td>
                <td data-label="Ratings">{movie.movieRatings}</td>
                <td data-label="Release Date">{movie.movieReleaseDate}</td>
                <td data-label="Actions">
                    <div className="ui small basic icon buttons">
                        <Button as={NavLink} to={`editMovie/${movie.id}`} className="ui button"><i className="search icon"></i></Button>
                        
                        <Button className="ui button" onClick={async () => {
                                await apiConnector.deleteMovie(movie.id!);
                                window.location.reload();
                            }}>
                            <i className="trash alternate icon"></i>
                        </Button>
                    </div>
                </td>
            </tr>
        </>
    )
}
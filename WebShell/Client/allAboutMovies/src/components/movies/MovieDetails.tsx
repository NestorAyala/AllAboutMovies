import {NavLink, useNavigate, useParams} from "react-router-dom";
import {MovieDTO} from "../../models/movieDTO.ts";
import {ChangeEvent, useEffect, useState} from "react";
import apiConnector from "../../api/apiConnector.ts";
import {Button, Form, Segment} from "semantic-ui-react";

export default function MovieDetails()
{
    const {id} = useParams();
    const navigate = useNavigate();
    
    const [movie, setMovie] = useState<MovieDTO>({
        id: undefined,
        movieTitle: '',
        moviePlot: '',
        movieGenre: '',
        movieActors: '',
        movieRatings: '',
        movieReleaseDate: ''
    });

    useEffect(() => {
        //If we do have an ID, that means we're in Edit/Details mode
        if (id){
            apiConnector.getMovieById(id).then(movie => setMovie(movie!));
        }
    }, [id]);
    
    function handleSubmit(){
        if (!movie.id){
            apiConnector.createMovie(movie).then(() => navigate('/'));
        }
        else { 
            apiConnector.editMovie(movie).then(() => navigate('/'));
        }
    }
    
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        const {name, value} = event.target;
        setMovie({...movie, [name]: value });
    }
    
    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete='off' className='ui inverted form'>
                <Form.Input placeholder='Title' name='movieTitle' value={movie.movieTitle} onChange={handleInputChange}/>
                <Form.TextArea placeholder='Plot' name='moviePlot' value={movie.moviePlot} onChange={handleInputChange}/>
                <Form.Input placeholder='Genre' name='movieGenre' value={movie.movieGenre} onChange={handleInputChange}/>
                <Form.Input placeholder='Actors' name='movieActors' value={movie.movieActors} onChange={handleInputChange}/>
                <Form.Input placeholder='Ratings' name='movieRatings' value={movie.movieRatings} onChange={handleInputChange}/>
                <Form.Input placeholder='2024-03-09' name='movieReleaseDate' value={movie.movieReleaseDate} onChange={handleInputChange}/>

                <Button floated='right' positive type='submit' content='Submit'/>
                <Button as={NavLink} to='/' floated='right' type='button' content='Cancel'/>
            </Form>
        </Segment>
    )
}
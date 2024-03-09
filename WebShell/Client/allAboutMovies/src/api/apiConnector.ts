import {MovieDTO} from "../models/movieDTO.ts";
import axios, {AxiosResponse} from "axios";
import {API_BASE_URL} from "../../config.ts";
import {GetMovieByIdResponse} from "../models/getMovieByIdResponse.ts";
import {GetMoviesResponse} from "../models/getMoviesResponse.ts";

const apiConnector = {
    getMovies: async (): Promise<MovieDTO[]> => {
        try {
            const response: AxiosResponse<GetMoviesResponse> = 
                await axios.get(`${API_BASE_URL}/movies`);
            
            const movies = response.data.moviesDto.map(movie => ({
                ...movie,
                movieReleaseDate: movie.movieReleaseDate?.slice(0, 10) ?? ""
            }));
            
            return movies;
        } 
        catch (error){
            console.log('Error trying to get movies: ', error);
            
            throw error;
        }
    },

    createMovie: async (movie: MovieDTO): Promise<void> => {
        try{
            await axios.post<number>(`${API_BASE_URL}/movies`, movie);
        }
        catch (error){
            console.log(error);
            
            throw error;
        }
    },

    editMovie: async (movie: MovieDTO): Promise<void> => {
        try{
            await axios.put<number>(`${API_BASE_URL}/movies/${movie.id}`, movie);
        }
        catch (error){
            console.log(error);

            throw error;
        }
    },

    deleteMovie: async (movieId: number): Promise<void> => {
        try{
            await axios.delete<number>(`${API_BASE_URL}/movies/${movieId}`);
        }
        catch (error){
            console.log(error);

            throw error;
        }
    },
    
    getMovieById: async (movieId: string): Promise<MovieDTO | undefined> => {
        try{
            const response = await axios.get<GetMovieByIdResponse>(`${API_BASE_URL}/movies/${movieId}`);
            
            return response.data.movieDto;
        }
        catch (error){
            console.log(error);

            throw error;
        }
    }
}

export default apiConnector;
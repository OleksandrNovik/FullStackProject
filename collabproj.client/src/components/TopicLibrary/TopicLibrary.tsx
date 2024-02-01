import TopicLibraryItem from "./TopicLibraryItem";
import Topic from "../../commonTypes/Topic";
import './TopicLibrary.css';

interface TopicLibraryProps {
    // Name of this topic library
    title: string;
    // List of topics to show
    topics: Topic[],
    // If user views topics in editor mode (for example creator of topics can change or delete items in library)
    isEditable: boolean;
}
// Component to represent library (list) of topics
// It is reused to view list of subtopics (if there are any) for each topic
function TopicLibrary({title, topics, isEditable}:TopicLibraryProps) {

    return <>
        {/*TODO: Create separate component to handle header changes*/} 
        { isEditable ? <input /> : <h1>{title}</h1>}
        <ul style={{listStyle: 'decimal', textAlign: 'left'}}>
            {topics.map(topic => 
                <TopicLibraryItem key={topic.id} topic={topic} isEditable={isEditable} />
            )}
        </ul>
    </>
}

export default TopicLibrary;
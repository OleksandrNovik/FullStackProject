import TopicLibraryItem from "./TopicLibraryItem";
import Topic from "../../commonTypes/Topic";
import './TopicLibrary.css';

interface TopicLibraryProps {
    // List of topics to show
    topics?: Topic[],
    // If user views topics in editor mode (for example creator of topics can change or delete items in library)
    isEditable: boolean;
}
// Component to represent library (list) of topics
// It is reused to view list of subtopics (if there are any) for each topic
function TopicLibrary({topics, isEditable}:TopicLibraryProps) {

    return <>
        {topics && 
            <ul style={{listStyle: 'decimal', textAlign: 'left'}}>
                {topics.map(topic => 
                    <TopicLibraryItem key={topic.id} topic={topic} isEditable={isEditable} />
                )}
            </ul>
        }
    </>
}

export default TopicLibrary;
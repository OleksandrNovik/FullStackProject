import { Link } from 'react-router-dom';
import './TopicItemContent.css';

interface TopicItemContentProps {
    // Is content editable or readonly
    isEditable:boolean;
    // id of topic to view or edit
    id:number;
    // Title of the topic
    title:string;
}
// Component to view content of current topic
// In this representation topic can be shown as it is or with additional options
// Edit topic and its subtopics or delete topic from the library
function TopicItemContent({isEditable, id, title}:TopicItemContentProps) {
    
    return <>
        <Link to={`/topic-library/view/${id}`}>{title}</Link>
        {isEditable && <div>
                        <button>ed</button> 
                        <button>del</button>
                    </div> }
    </>
}

export default TopicItemContent;
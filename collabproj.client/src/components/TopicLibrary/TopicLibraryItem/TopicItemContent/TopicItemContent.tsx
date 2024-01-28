import './TopicItemContent.css';

interface TopicItemContentProps {
    // Is content editable or readonly
    isEditable:boolean;
    // Title of the topic
    title:string;
    // Switch for editing current topic or its subtopics
    editSubTopics:()=>JSX.Element | undefined;
}
// Component to view content of current topic
// It can make it editable or readonly
function TopicItemContent({isEditable, title, editSubTopics}:TopicItemContentProps) {
    
    return <>
        {!isEditable ? <a href="#">{title}</a> :
            <>
                <input type="text" />
                <button>del</button>
            </>}
        { editSubTopics() }
    </>
}

export default TopicItemContent;
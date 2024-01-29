import Topic from "../../commonTypes/Topic";
import TopicContentSection from "./TopicContentSection";

interface TopicViewProps {
    isEditable: boolean;
    topic: Topic;
}

function TopicView({topic, isEditable}:TopicViewProps) {
    return <div>
        { isEditable ? <h3> {topic.name} </h3> : <input /> }
        <TopicContentSection items={[]} isEditable={false} />
        {isEditable && <button> Save changes </button>}
    </div>
}

export default TopicView;
import Topic from "../../commonTypes/Topic";
import TopicContentSection from "./TopicContentSection";

interface TopicViewProps {
    isEditable: boolean;
    topic: Topic;
}
// Component to show the topic and all the content it has
function TopicView({topic, isEditable}:TopicViewProps) {

    // Title of topic can be editable or readonly
    return <div>
        { isEditable ?  <input /> : <h1> {topic.name} </h1> }
        {/* Each topic has content section to show all headers, text section or other staff */}
        <TopicContentSection items={[
            {
                id: 1, type: 'header', innerText: 'HELLO'
            },
            {
                id: 2, type: 'text', innerText: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nobis ipsum nam eligendi. Labore magnam, dolorum, quos suscipit obcaecati officiis nihil vero ea commodi ut omnis? Eum, minima? Minus, facere sed?'
            },
            {
                id: 2, type: 'code', innerText: 'function Play() {}'
            }
        ]} isEditable={isEditable} />
        { isEditable && <button> Save changes </button> }
    </div>
}

export default TopicView;